using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Core;

namespace EWS.Domain.Model
{
    public class Test : Entity<Guid>
    {
        internal Test(Guid id, string testName)
        {
            if (id == null || id == Guid.Empty) throw new ArgumentNullException("Test entity must have an id.");
            if (string.IsNullOrWhiteSpace(testName)) throw new ArgumentException("Test Names cannot be empty");
            this.Id = id;
            this.TestName = testName;
        }

        public string TestName { get; set; }
    }
}
