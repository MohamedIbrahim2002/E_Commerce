namespace E_Commerce.Application.Common
{
    public record Error (string Code , string Description ,   ErrorType ErrorType =  ErrorType.Failure)
    {
        public static Error Failure(string code = "General.Failure" , string description = "General Failure has occured") => new(code , description, ErrorType.Failure);
        public static Error Validation(string code = "General.Validation", string description = "General validation has occured") => new(code, description, ErrorType.Validation);
        public static Error NotFound(string code = "General.NotFound", string description = "General not found has occured") => new(code, description, ErrorType.NotFound);
        public static Error Conflict(string code = "General.conflict", string description = "General conflict has occured") => new(code, description, ErrorType.Conflict);
        public static Error UnAuthorized(string code = "General.unauthorize", string description = "General unathorize has occured") => new(code, description, ErrorType.UnAuthorized);
        public static Error Forbidden (string code = "General.forbidden", string description = "General unauthorize has occured") => new(code, description, ErrorType.Forbidden);
        public static Error InValidCredential(string code = "General.invalidcredential", string description = "General invalidcredential has occured") => new(code, description, ErrorType.InValidCredential);

    }
    public enum ErrorType
    {
        Failure = 0,
        Validation = 1,
        NotFound= 2,
        Conflict = 3,
        UnAuthorized = 4,
        Forbidden = 5,
        InValidCredential = 6
    }


}