using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Common
{
    public static class ErrorMessages
    {
        public const string RequiredMessage = "The field {0} is required!";
        public const string LengthErrorMessage = "The field {0} must be between {2} and {1} characters long!";

        //---------

        public const string CategoryDoesNotExist = "Category does not exist.";
    }
}
