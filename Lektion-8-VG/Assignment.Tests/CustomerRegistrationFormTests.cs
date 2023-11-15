using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    public class CustomerRegistrationFormTests
    {
        [Fact]
        public void CustomerRegistrationForm_Should_BeOfType_CustomerRegistratonForm()
        {
            // arrange
            var form = new CustomerRegistrationForm();

            // assert
            Assert.IsType<CustomerRegistrationForm>(form);
        }
    }
}
