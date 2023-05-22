using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StatusManager : IStatusService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StatusManager(IUnitofWork unitofWork,IHttpContextAccessor httpContextAccessor)
        {
           _unitofWork = unitofWork;
           _httpContextAccessor = httpContextAccessor;
        }

        public IResult UpdateStatus(int requestId, short? statusId)
        {
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            Request? request = _unitofWork.Request.GetAll(r => r.Id == requestId).SingleOrDefault();
            if (request == null)
            {
                return new ErrorResult(Messages.RequestDoesNotExist);
            }

            bool checkStatus = StatusValidator.Validate(request, userId, statusId);

            if (checkStatus)
            {
                if (statusId == ((short)AvailableStatus.Lock) || statusId == ((short)AvailableStatus.Reject))
                {
                    History history = new History() { UserId = userId, RequestId = requestId, Date = DateTime.Now }; ;
                    if (statusId == ((short)AvailableStatus.Lock) && request.StatusId == ((short)AvailableStatus.Wait))
                    {
                        request.StatusId = (short)statusId;
                        _unitofWork.Request.Update(request);
                        history.Message = "Sorğunu gözləmədən çıxardı";
                    }
                    else
                    {
                        request.StatusId = (short)statusId;
                        request.ExecutorId = userId;
                        _unitofWork.Request.Update(request);
                        history.Message = statusId == ((short)AvailableStatus.Lock) ? Messages.LockMessage : statusId == ((short)AvailableStatus.Reject) ? Messages.RejectMessage : "";
                    }
                    _unitofWork.History.Add(history);
                    return new SuccessResult(Messages.SuccessfullyUpdated);
                }
                else if (statusId == ((short)AvailableStatus.Close) || statusId == ((short)AvailableStatus.Wait) || statusId == ((short)AvailableStatus.Confirm))
                {
                    request.StatusId = (short)statusId;
                    _unitofWork.Request.Update(request);
                    History history = new History() { UserId = userId, RequestId = requestId, Message = statusId == ((short)AvailableStatus.Close) ? Messages.CloseMessage : statusId == ((short)AvailableStatus.Wait) ? Messages.WaitMessage : statusId == ((short)AvailableStatus.Confirm) ? Messages.ConfirmMessage : "", Date = DateTime.Now };
                    _unitofWork.History.Add(history);
                    return new SuccessResult(Messages.SuccessfullyUpdated);
                }
            }
            return new ErrorResult();
        }
    }
}
