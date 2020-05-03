# Exercise: People Counter

## Goal

Form pairs and discuss how you can refactor the code. Make notes on the different steps you would take to do this in a safe way. 

## Domain

For safety, we need to make sure we don't exceed the maximum occupancy in any zone of the building. 

We've installed cameras pointed at all the entrances of each zone of the building. The cameras can count people coming in and going out. We can query this data using the cameras' API. We calculate the occupancy of each zone and regularly show that on a monitor in the security's control room.

## Tips

Some questions you can ask yourselves:

- Can we epxress the domain language better? What domain concepts are implicit?
- Are there any (DDD) design patterns we can use? Can we make use of immutability? Are there opportunities for introducing better abstractions?
- How can we test this code (or make it more testable)?
- Can we isolate side effects? Can we introduce Hexagonal Architecture (aka Ports & Adapters)?

Advanced:
- Rewrite this in a FP language (or using FP style in an OOP language).
- Find opportunities to use monoids, map/fold/filter/...
