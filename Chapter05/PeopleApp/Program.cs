using Packt.Shared;
 
 Person bob = new();
 bob.Name = "Bruno";
 bob.DateOfBirth = new DateTime(1965, 12, 22);

 WriteLine(format:
    "{0} was born on {1:dddd, d MMMM yyyy}",
     arg0: bob.Name, 
     arg1: bob.DateOfBirth);