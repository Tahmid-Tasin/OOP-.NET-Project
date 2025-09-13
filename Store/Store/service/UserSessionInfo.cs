// File: service/auth/UserSession.cs
using System;

namespace Store.service
{
    public enum UserRole
    {
        Guest = 0,
        Admin = 1,
        Manager = 2,   // "Company Manager"
        Customer = 3,
    }

    public sealed class UserIdentity
    {
        public bool IsAuthenticated { get; private set; }
        public UserRole Role { get; private set; } = UserRole.Guest;

        // Common
        public string DisplayName { get; private set; } = "Unknown";
        public string Email { get; private set; } = "";
        public int? UserId { get; private set; }

        // For managers
        public int? CompanyId { get; private set; }
        public string CompanyName { get; private set; } = "";

        public static UserIdentity Guest() => new UserIdentity();

        public static UserIdentity FromAdmin(Admin admin, string email = null)
        {
            if (admin == null) return Guest();
            string full = $"{(admin.FirstName ?? "").Trim()} {(admin.LastName ?? "").Trim()}".Trim();
            return new UserIdentity
            {
                IsAuthenticated = true,
                Role = UserRole.Admin,
                DisplayName = string.IsNullOrWhiteSpace(full) ? (admin.UserName ?? "Admin") : full,
                Email = email ?? "",
                UserId = admin.Id
            };
        }

        public static UserIdentity FromManager(Employee emp)
        {
            if (emp == null) return Guest();
            return new UserIdentity
            {
                IsAuthenticated = true,
                Role = UserRole.Manager,
                DisplayName = string.IsNullOrWhiteSpace(emp.NAME) ? "Company Manager" : emp.NAME,
                Email = emp.EMAIL ?? "",
                UserId = emp.ID,
                CompanyId = emp.CompanyId,
                CompanyName = emp.Company?.Name ?? "Company"
            };
        }

        public static UserIdentity FromCustomer(Customer c)
        {
            if (c == null) return Guest();
            return new UserIdentity
            {
                IsAuthenticated = true,
                Role = UserRole.Customer,
                DisplayName = string.IsNullOrWhiteSpace(c.FullName) ? "Customer" : c.FullName,
                Email = c.Email ?? "",
                UserId = c.Id
            };
        }
    }

    public static class UserSession
    {
        public static UserIdentity Current { get; private set; } = UserIdentity.Guest();

        public static void SignIn(UserIdentity identity)
        {
            Current = identity ?? UserIdentity.Guest();
        }

        public static void SignOut()
        {
            Current = UserIdentity.Guest();
        }

        public static bool IsInRole(UserRole role) => Current?.Role == role && Current.IsAuthenticated;
    }
}
