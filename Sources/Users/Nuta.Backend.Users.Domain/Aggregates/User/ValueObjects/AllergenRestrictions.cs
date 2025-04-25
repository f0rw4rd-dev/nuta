using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.Aggregates.User.ValueObjects;

public class AllergenRestrictions : ValueObject
{
    public bool HasGlutenAllergy { get; }

    public bool HasMilkAllergy { get; }

    public bool HasEggAllergy { get; }

    public bool HasNutAllergy { get; }

    public bool HasPeanutAllergy { get; }

    public bool HasSesameSeedAllergy { get; }

    public bool HasSoyAllergy { get; }

    public bool HasCeleryAllergy { get; }

    public bool HasMustardAllergy { get; }

    public bool HasLupinAllergy { get; }

    public bool HasFishAllergy { get; }

    public bool HasCrustaceanAllergy { get; }

    public bool HasMolluskAllergy { get; }

    public bool HasSulphiteAllergy { get; }

    private AllergenRestrictions()
    {
    }

    private AllergenRestrictions(
        bool hasGlutenAllergy,
        bool hasMilkAllergy,
        bool hasEggAllergy,
        bool hasNutAllergy,
        bool hasPeanutAllergy,
        bool hasSesameSeedAllergy,
        bool hasSoyAllergy,
        bool hasCeleryAllergy,
        bool hasMustardAllergy,
        bool hasLupinAllergy,
        bool hasFishAllergy,
        bool hasCrustaceanAllergy,
        bool hasMolluskAllergy,
        bool hasSulphiteAllergy)
    {
        HasGlutenAllergy = hasGlutenAllergy;
        HasMilkAllergy = hasMilkAllergy;
        HasEggAllergy = hasEggAllergy;
        HasNutAllergy = hasNutAllergy;
        HasPeanutAllergy = hasPeanutAllergy;
        HasSesameSeedAllergy = hasSesameSeedAllergy;
        HasSoyAllergy = hasSoyAllergy;
        HasCeleryAllergy = hasCeleryAllergy;
        HasMustardAllergy = hasMustardAllergy;
        HasLupinAllergy = hasLupinAllergy;
        HasFishAllergy = hasFishAllergy;
        HasCrustaceanAllergy = hasCrustaceanAllergy;
        HasMolluskAllergy = hasMolluskAllergy;
        HasSulphiteAllergy = hasSulphiteAllergy;
    }

    public static AllergenRestrictions Create()
    {
        return new AllergenRestrictions(
            hasGlutenAllergy: false,
            hasMilkAllergy: false,
            hasEggAllergy: false,
            hasNutAllergy: false,
            hasPeanutAllergy: false,
            hasSesameSeedAllergy: false,
            hasSoyAllergy: false,
            hasCeleryAllergy: false,
            hasMustardAllergy: false,
            hasLupinAllergy: false,
            hasFishAllergy: false,
            hasCrustaceanAllergy: false,
            hasMolluskAllergy: false,
            hasSulphiteAllergy: false);
    }
}