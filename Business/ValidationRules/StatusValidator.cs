using Entities.Concrete;
using Entities.Enums;

namespace Business.ValidationRules
{
    public static class StatusValidator
    {
        public static bool Validate(Request request, int userId, short? statusId)
        {
            if (request.SenderId == userId)
            {
                if (request.StatusId == ((short)AvailableStatus.Close) && statusId != ((short)AvailableStatus.Confirm))
                {
                    return false;
                }
                else if (request.StatusId != ((short)AvailableStatus.Close) && statusId != null)
                {
                    return false;
                }
            }
            else if (request.SenderId != userId)
            {
                if (request.StatusId == ((short)AvailableStatus.Open) && (statusId != ((short)AvailableStatus.Lock) && statusId != ((short)AvailableStatus.Reject)))
                {
                    return false;
                }
                else if (request.StatusId == ((short)AvailableStatus.Close) && statusId != null)
                {
                    return false;
                }
                else if (request.StatusId == ((short)AvailableStatus.Lock))
                {
                    if (request.ExecutorId == userId && (statusId != ((short)AvailableStatus.Close) && statusId != ((short)AvailableStatus.Wait)))
                    {
                        return false;
                    }
                    else if (request.ExecutorId != userId && statusId != null)
                    {
                        return false;
                    }
                }
                else if (request.StatusId == ((short)AvailableStatus.Wait))
                {
                    if (request.ExecutorId == userId && statusId != ((short)AvailableStatus.Lock))
                    {
                        return false;
                    }
                    else if (request.ExecutorId != userId && statusId != null)
                    {
                        return false;
                    }
                }
                else if (request.StatusId == ((short)AvailableStatus.Confirm) && statusId != null)
                {
                    return false;
                }
                else if (request.StatusId == ((short)AvailableStatus.Reject) && statusId != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}