﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Mess_Management_System.Common_Daterange_Attribute
{
    public class CurrentorGreaterDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            int dy = dateTime.Day;
            DateTime dateTimeNow = DateTime.Now;
            int dty = dateTimeNow.Day;

            if (dy >= dty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
