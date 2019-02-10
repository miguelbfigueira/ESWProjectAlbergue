// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-07-2019
//
// Last Modified By : migue
// Last Modified On : 01-06-2019
// ***********************************************************************
// <copyright file="CheckDateRangeAttribute.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESWProjectAlbergue.Models
{
    /// <summary>
    /// Class CheckDateRange. This class cannot be inherited.
    /// Implements the <see cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class CheckDateRange : ValidationAttribute
    {
        /// <summary>
        /// Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>An instance of the <see cref="System.ComponentModel.DataAnnotations.ValidationResult"></see> class.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime _birthJoin = Convert.ToDateTime(value);
                
                if (CalculateAge(_birthJoin) <= 18 )
                {
                    return new ValidationResult("Tem de ter mais de 18 anos");
                }
                if (_birthJoin >= DateTime.Now)
                {
                    return new ValidationResult("A data de nascimento tem de ser anterior a hoje.");
                }
               
            }

            return ValidationResult.Success;
        }

        /// <summary>
        /// Calculates the age.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>System.Int32.</returns>
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
