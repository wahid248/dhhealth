namespace Web.Utilities
{
    public static class RegExValidation
    {
        public const string Name = "^(([A-Za-z]+[ ]?|[a-z]+[']?[ ]?)+)$";
        public const string Email = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
        public const string Message = @"^[+-=()&%""? _,@.A-Za-z0-9](.|\n)*$";
        public const string PhoneNo = @"^[+88]\d{13}|[88]\d{12}|\d{11}$";
    }
}
