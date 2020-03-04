namespace LoginBC.Models {

    public enum TypeAuth {
        Ok,
        Unauthorized,
        NotFound
    }

    public class Auth {

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
