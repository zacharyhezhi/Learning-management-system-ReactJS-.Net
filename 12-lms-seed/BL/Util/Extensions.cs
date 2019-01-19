using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Util
{
    public static class Extensions
    {
        public static IEnumerable<Student> ApplySort(this IEnumerable<Student> students, string sortString, string sortOrder)
        {
            var isAscending = false;
            if (!string.IsNullOrEmpty(sortOrder))
            {
                isAscending = !(sortOrder.ToLower() == "desc");
            }
            if (string.IsNullOrEmpty(sortString))
            {
                sortString = "id";
            }
            switch (sortString.ToLower())
            {
                case "id":
                    return isAscending ? students.OrderBy(x => x.Id) : students.OrderByDescending(x => x.Id);
                case "name":
                    return isAscending ? students.OrderBy(x => x.FirstName) : students.OrderByDescending(x => x.FirstName);
                case "email":
                    return isAscending ? students.OrderBy(x => x.Email) : students.OrderByDescending(x => x.Email);
                case "dateofbirth":
                    return isAscending ? students.OrderBy(x => x.DateOfBirth) : students.OrderByDescending(x => x.DateOfBirth);
                default:
                    return students.OrderBy(x => x.Id);
            }
        }
        public static IEnumerable<Student> Search(this IEnumerable<Student> students, string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                return students;
            }

            return students.Where(x => x.FirstName.Contains(searchValue)
                                    || x.LastName.Contains(searchValue)
                                    || x.Email.Contains(searchValue));
        }
    }
}
