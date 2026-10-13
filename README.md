# Design Patterns

All 23 Gang of Four patterns, written by hand and reviewed.
In C#.

Reference course: Dmitri Nesteruk, *Design Patterns in C# and .NET*.

## Layout

```
DesignPatterns.slnx          one solution for every C# project
Directory.Build.props        shared C# settings (.NET 10, nullable, warnings as errors)
Creational/  Structural/  Behavioral/
  <Pattern>/
    CSharp/<Pattern>/        console project
```

## For each pattern

- What problem it solves
- The code
- When **not** to use it
- Where .NET already uses it

## Order (⭐ = asked most in interviews)

| # | Pattern | Status |
|---|---|---|
| 1 | ⭐ Singleton | |
| 2 | ⭐ Factory — Simple Factory, Factory Method, Abstract Factory (`Creational/Factory`) | |
| 3 | ⭐ Builder | |
| 4 | ⭐ Strategy | |
| 5 | ⭐ Observer | |
| 6 | ⭐ Decorator | |
| 7 | ⭐ Adapter | |
| 9 | ⭐ Proxy | |
| 10 | ⭐ Facade | |
| 11 | Command | |
| 12 | Template Method | |
| 13 | State | |
| 14 | Chain of Responsibility | |
| 15 | Composite | |
| 16 | Iterator | |
| 17 | Prototype | |
| 18 | Mediator | |
| 19 | Bridge | |
| 20 | Flyweight | |
| 21 | Memento | |
| 22 | Visitor | |
| 23 | Interpreter | |
