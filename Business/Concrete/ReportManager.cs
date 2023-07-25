using Aspose.Cells;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using ClosedXML.Excel;
using Core.Utilities.Helpers.ExcelHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Enums;
using FastMember;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IConfiguration _configuration { get; }
        public ReportManager(IUnitofWork unitofWork,IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;

        }
        public IDataResult<List<ReportDto>> GetAllReports()
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var allhistories = _unitofWork.History.GetAll()
                 .Include(h => h.Request.Category)
                 .Include(h => h.Request.Status)
                 .Include(h => h.Request.Executor)
                 .Include(h => h.Request.Sender);

            var userhistories = allhistories.Where(h => h.Request.Executor.Id == id || h.Request.Sender.Id == id);

            if(userhistories.Count()==0) return new ErrorDataResult<List<ReportDto>>(null,Messages.NullData);


            List<ReportDto> reportdtos = new List<ReportDto>();
            

            foreach (var history in userhistories)
            {
                if(history.Message == Messages.CloseMessage|| history.Message == Messages.ConfirmMessage)
                {
                    ReportDto newreport = new ReportDto();
                    newreport.Id = history.Request.Id;
                    newreport.CategoryName = history.Request.Category.Name;
                    newreport.SenderName = history.Request.Sender.UserName;
                    newreport.ExecutorName = history.Request.Executor.UserName;
                    newreport.Date = history.Request.Date;
               


                    newreport.StatusName =
                    (history.Message == Messages.CloseMessage) ? AvailableStatus.Close.ToString() :
                    (history.Message == Messages.ConfirmMessage) ? AvailableStatus.Confirm.ToString() : null;

                    newreport.FirstExecuteDate = userhistories.Where(h => h.RequestId == newreport.Id && h.Message == Messages.LockMessage).SingleOrDefault().Date;

                    newreport.CloseDate = history.Date;

                    TimeSpan subtraction = ((TimeSpan)(newreport.CloseDate - newreport.FirstExecuteDate));
                    int nonWorkingDayCount = _unitofWork.NonWorkingDay.GetAll(p => newreport.FirstExecuteDate < p.Date && p.Date < newreport.CloseDate).Count();
                    double executionPeriod = subtraction.TotalHours - (subtraction.Days * (24 - 9)) - nonWorkingDayCount * 9;

                    newreport.ExecuteTime = executionPeriod;

                    reportdtos.Add(newreport);
                }
                
            }

            return new SuccessDataResult<List<ReportDto>>(reportdtos, Messages.SuccessfullyListed);
        }

        public IDataResult<byte[]> ReportImportToExcel()
        {

            var data = GetAllReports().Data;

            if(data == null) return new ErrorDataResult<byte[]>(null,Messages.NullData);

            var file=ListToExcelHelpers.ExportToExcel<ReportDto>(data);
           
            return new SuccessDataResult<byte[]>(file,Messages.SuccessfullyDownloaded);
        }
    }
}
