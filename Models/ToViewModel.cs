using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDetailsCRUD.Models
{
    public class ToViewModel
    {
        public Tbl_Employee ToEmployee(EmployeeDataModel model)
        {
            return new Tbl_Employee
            {
                Emp_ID = model.Emp_ID,
                Emp_Code=model.Emp_Code.Trim(),
                Emp_Name=model.Emp_Name.Trim(),
                Address=model.Address.Trim(),
                Email_ID=model.Email_ID.Trim(),
                Phone_No=model.Phone_No.Trim(),
                Designation=model.Designation.Trim()
            };

        }

        public EmployeeDataModel ToEmployeeDataModel(Tbl_Employee model)
        {
            return new EmployeeDataModel
            {
                Emp_ID = model.Emp_ID,
                Emp_Code = model.Emp_Code.Trim(),
                Emp_Name = model.Emp_Name.Trim(),
                Address = model.Address.Trim(),
                Email_ID = model.Email_ID.Trim(),
                Phone_No = model.Phone_No.Trim(),
                Designation = model.Designation.Trim()
            };

        }
    }

}