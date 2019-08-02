using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComcastMoviesApplication.Helpers
{
    public class ValidationHelper
    {
        public  bool IsValidFindMovieRequest(string title,string yearOfRelease,string genre)
        {
            if(string.IsNullOrEmpty(title) && string.IsNullOrEmpty(yearOfRelease) && string.IsNullOrEmpty(genre))
            {
                return false;
            }

            if(!string.IsNullOrEmpty(yearOfRelease))
            {
                int convertedYearOfRelease;
                if(!int.TryParse(yearOfRelease,out convertedYearOfRelease))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsValidGuid(string guid ,out Guid? returnedGuid)
        {
            if (string.IsNullOrEmpty(guid))
            {
                returnedGuid = null;
                return false;
            }
            Guid convertedGuid;
            if (!Guid.TryParse(guid, out convertedGuid))
            {
                returnedGuid = null;
                    return false;
            }

            returnedGuid = convertedGuid;
            return true;
        }

        public bool IsValidEditMovieRatingRequest(string userId, string movieId, string rating)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(movieId)) return false;
            Guid guidUserId;
            Guid guidMovieId;
            int intRating;
            if (!Guid.TryParse(userId, out guidUserId)) return false;
            if (!Guid.TryParse(movieId, out guidMovieId)) return false;
            if (!int.TryParse(rating, out intRating)) return false;
            if (intRating < 1 || intRating > 5) return false;
            return true;
        }
    }
}