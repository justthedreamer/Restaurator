using Core.ValueObject.PromoCode;

namespace Application.DTO;

public class PromoCodeDto
{
    public required PromoCodeId PromoCodeId { get; init; }
    public required PromoCodeName PromoCodeName { get; init; }
    public required PromoCodeState PromoCodeState { get; init; }
    public required PromoCodeKey PromoCodeKey { get; init; }
    public required PromoCodeValueType PromoCodeValueType { get; init; }
    public required PromoCodeValue PromoCodeValue { get; init; }

    public PromoCodeDto(PromoCodeId promoCodeId, PromoCodeName promoCodeName, PromoCodeState promoCodeState,
        PromoCodeKey promoCodeKey, PromoCodeValueType promoCodeValueType, PromoCodeValue promoCodeValue)
    {
        PromoCodeId = promoCodeId;
        PromoCodeName = promoCodeName;
        PromoCodeState = promoCodeState;
        PromoCodeKey = promoCodeKey;
        PromoCodeValueType = promoCodeValueType;
        PromoCodeValue = promoCodeValue;
    }

    public PromoCodeDto()
    {
    }
}