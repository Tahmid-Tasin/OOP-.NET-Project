// File: service/auth/UserSession.cs
using System;

namespace Store.service
{
    public enum UserRole { Guest = 0, Admin = 1, Manager = 2, Customer = 3 }

    public sealed class UserIdentity
    {
        public bool IsAuthenticated { get; private set; }
        public UserRole Role { get; private set; } = UserRole.Guest;
        public int? UserId { get; private set; }
        public string DisplayName { get; private set; } = "Unknown";
        public string Email { get; private set; } = "";

        // Manager-only
        public int? CompanyId { get; private set; }
        public string CompanyName { get; private set; } = "";

        public static UserIdentity Guest() => new UserIdentity();

        public static UserIdentity FromAdmin(Admin a, string email = null)
        {
            if (a == null) return Guest();
            string full = $"{(a.FirstName ?? "").Trim()} {(a.LastName ?? "").Trim()}".Trim();
            return new UserIdentity
            {
                IsAuthenticated = true,
                Role = UserRole.Admin,
                UserId = a.Id,
                DisplayName = string.IsNullOrWhiteSpace(full) ? (a.UserName ?? "Admin") : full,
                Email = email ?? ""
            };
        }

        public static UserIdentity FromManager(Employee e)
        {
            if (e == null) return Guest();
            return new UserIdentity
            {
                IsAuthenticated = true,
                Role = UserRole.Manager,
                UserId = e.ID,
                DisplayName = string.IsNullOrWhiteSpace(e.NAME) ? "Company Manager" : e.NAME,
                Email = e.EMAIL ?? "",
                CompanyId = e.CompanyId,
                CompanyName = e.Company?.Name ?? "Company"
            };
        }

        public static UserIdentity FromCustomer(Customer c)
        {
            if (c == null) return Guest();
            return new UserIdentity
            {
                IsAuthenticated = true,
                Role = UserRole.Customer,
                UserId = c.Id,
                DisplayName = string.IsNullOrWhiteSpace(c.FullName) ? "Customer" : c.FullName,
                Email = c.Email ?? ""
            };
        }
    }

    public static class UserSession
    {
        public static UserIdentity Current { get; private set; } = UserIdentity.Guest();
        public static string LastLoginUserType { get; set; } = "Customer";
        public static event Action OnChanged;

        public static void SignIn(UserIdentity identity)
        {
            Current = identity ?? UserIdentity.Guest();
            OnChanged?.Invoke();
        }

        public static void SignOut()
        {
            try { CartStore.Clear(); } catch {}

            Current = UserIdentity.Guest();
            OnChanged?.Invoke();
        }

        public static bool IsInRole(UserRole role) =>
            Current?.IsAuthenticated == true && Current.Role == role;
    }
}
