using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIJIA.Models
{
    public class RoleViewModel
    {
        public RoleViewModel() {}

        public RoleViewModel(UserRole userRole)
        {
            Id = userRole.Id;
            Name = userRole.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }


    }
}