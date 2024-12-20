namespace OnlineShop.Core.Dto.Auth;

public class CreateUserRequest
{
    public CreateUserRequest(string firstName, string lastName, string email, string userName, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        Password = password;
    }

    public string FirstName { get;  }
    public string LastName { get;  }
    public string Email { get;  }
    public string UserName { get; }
    public string Password { get;  }
}