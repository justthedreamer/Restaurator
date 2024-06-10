using Core.Model.StaffModel;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace CoreUnitTests.Utilities;

public static class EmployeeFactory
{
    /// <summary>
    /// Create employee with Waiter position. <br />
    /// First name : Adam <br />
    /// Last name : Malysz <br />
    /// Email : email@email.com <br />
    /// Password : password <br />
    /// </summary>
    /// <param name="employeeId">Unique ID</param>
    /// <returns></returns>
    public static Employee CreateEmployeeWaiter(UserId employeeId)
    {
        return new Employee(employeeId,"adam.malysz", "Adam", "Małysz", new Credentials("email@email.com", "password"),
            UserRole.Employee,EmployeePosition.Waiter,"698123578");
    }
}