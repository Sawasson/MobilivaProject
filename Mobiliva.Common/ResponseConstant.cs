﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Common
{
    public static class ResponseConstant
    {
        public const string RecordFound = "Record Found";
        public const string RecordNotFound = "Record Not Found";
        public const string RecordCreateSuccessfully = "Record Create Successfully";
        public const string RecordCreateNotSuccessfully = "Record Create Not Successfully";
        public const string RecordUpdateSuccessfully = "Record Update Successfully";
        public const string RecordUpdateNotSuccessfully = "Record Update Not Successfully";
        public const string RecordRemoveNotSuccessfully = "Record Remove Not Successfully";
        public const string RecordRemoveSuccessfully = "Record Remove Successfully";
        public const string IdNotNull = "Id value not null";
        public const string InvalidAuthentication = "Invalid Authentication";
        public const string TokenResponseMessage = "Token Create Successfull";
        public const string PaymentSuccessfull = "Payment Successfull";
        public const string OrderInfo = "OrderInfo";


        //---------------------------------------------------------------------------------------//
        public const string Admin_Role = "Administrator";
        public const string Customer_Role = "Customer";

        public const string Admin_Email = "sawasson@hotmail.com";
        public const string Admin_Password = "Admin123!";
        //---------------------------------------------------------------------------------------//
        public const string LoginUserInfo = "Enter User Info";
        //---------------------------------------------------------------------------------------//
        public const string MailTagHelperSuffix = "hotmail.com";

        //---------------------------------------------------------------------------------------//
        public const string Role_Admin = "Admin";
        public const string Role_Customer = "Customer";
        //-----------------------------------------------------------------------------------------//
        public const string BaseApiUrl = "http://localhost:25244";
        public const string ImageServerUrl = "  http://localhost:5000/";
        //-----------------------------------------------------------------------------------------//
        public const string Status_Pending = "Pending";
        public const string Status_Cancelled = "Cancelled";
        public const string Status_Completed = "Completed";
    }
}
