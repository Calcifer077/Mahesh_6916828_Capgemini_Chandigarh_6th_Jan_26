using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Account, AccountDetailsDto>()
            .ForMember(dest => dest.MaskedAccountNumber,
                opt => opt.MapFrom(src => MaskAccountNumber(src.AccountNumber)));
    }

    private string MaskAccountNumber(string accountNumber)
    {
        if (string.IsNullOrEmpty(accountNumber) || accountNumber.Length < 4)
            return "****";

        return "**** **** **** " + accountNumber.Substring(accountNumber.Length - 4);
    }
}