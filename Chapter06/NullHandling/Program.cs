//exemplo de como habilitar o desabilitar nullable no arquivo
// #nullable disable

using NullHandling;

int thisCannotBeNull = 4;
// thisCannotBeNull = null; //compile error!
WriteLine(thisCannotBeNull);
int? thisCouldBeNull = null;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());
thisCouldBeNull = 7;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

//the actual type of int? is Nullable<int>
Nullable<int> thisCouldBeAlsoNull = null;
thisCouldBeAlsoNull = 9;
WriteLine(thisCouldBeAlsoNull);

Address address = new()
{
    Building = null,
    Street = null!, //null forgiving operator
    City = "London",
    Region = "UK"
};

WriteLine(address.Building?.Length);
WriteLine(address.Street.Length);

