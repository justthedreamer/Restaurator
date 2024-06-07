using Core.Exceptions.User;
using Core.ValueObject.PromoCode;

namespace Core.Exceptions.PromoCode;

/// <summary>
/// Thrown if provided promotional code type is incorrect with provided promotional code value.
/// </summary>
public class PromoCodeInvalidArgumentsException(PromoCodeValueType valueType,PromoCodeValue promoCodeValue) : BadRequestException($"Cannot create promotional code for type : {valueType} with given value : {promoCodeValue} ");
