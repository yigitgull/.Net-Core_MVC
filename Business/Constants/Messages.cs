using System;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Constants
{
	public static class Messages
	{
		public static string ProductAdded = "Product is added.";

		public static string ProductNameInvalid = "Product name is invalid";

		public static string MaintenanceTime = "Maintenance time ";

		public static string ProductListed = "Products are listed.";

		public static string ProductConutOfCategoryError = " out of limit";

        public static string ProductNameAlreadyExistError = "Product Name exist.";

		public static string AuthorizationDenied = "No auto";
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
        internal static string ProductUpdated;
    }
}

