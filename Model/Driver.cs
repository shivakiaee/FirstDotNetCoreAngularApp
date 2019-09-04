using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace Model
{
    public class Driver:User
    {
        public virtual ICollection<Car> Cars { get; set; }
    }
}
