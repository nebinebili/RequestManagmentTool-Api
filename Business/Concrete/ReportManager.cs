using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public IConfiguration _configuration { get; }
        public ReportManager(IUnitofWork unitofWork,IMapper mapper, IConfiguration configuration)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _configuration = configuration;

        }
        public IDataResult<List<ReportDto>> GetAllReports()
        {
            var histories = _unitofWork.History.GetAll()
                 .Include(h => h.Request.Category)
                 .Include(h => h.Request.Status)
                 .Include(h => h.Request.Executor)
                 .Include(h => h.Request.Sender);

            List<ReportDto> reportdtos = new List<ReportDto>();
            

            foreach (var history in histories)
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

                    newreport.FirstExecuteDate = histories.Where(h => h.RequestId == newreport.Id && h.Message == Messages.LockMessage).SingleOrDefault().Date;

                    newreport.CloseDate = history.Date;

                    reportdtos.Add(newreport);
                }
                
            }

            return new SuccessDataResult<List<ReportDto>>(reportdtos, Messages.SuccessfullyListed);
        }

        public IResult ReportImportToExcel()
        {
            string str = _configuration.GetSection("FilePaths").GetSection("ExcelFilePath").Value;

            

            var data = GetAllReports().Data;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using(ExcelPackage excel=new ExcelPackage()) 
            {
                excel.Workbook.Worksheets.Add("Reports").Cells[1, 1].LoadFromCollection(data, true);
                excel.SaveAs(new FileInfo(str));
            }
            return new SuccessResult();
        }
    }
}
