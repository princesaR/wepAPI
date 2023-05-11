//using System;
//using System.ComponentModel.DataAnnotations;

//namespace ValidationAttributes
//{
//    public class RecoveryDateAfterPositiveResultAttribute : ValidationAttribute
//    {
//        public override bool IsValid(object value)
//        {
//            var recoveryDate = (DateTime)value;

//            // Get the instance of the containing class
//            var instance = ValidationContext.ObjectInstance as CoronaPatientDto;

//            if (instance != null && recoveryDate < instance.PositiveResult)
//            {
//                return false;
//            }

//            return true;
//        }
//    }
//}
