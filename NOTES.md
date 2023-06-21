# Learn about the domain: Cary's Cars

Cary's Cars is a car-sharing service that started operating in Amsterdam 6 months ago.
The service operates 300 vehicles that are spread out over the compact city center.
All vehicles are fully electric vehicles because of demands by the city as part of granting the free-floating fleet operating agreement.

After the customers reserved a car, they have 20 minutes to reach it.
If the vehicle is in good shape then they accept a rental agreement using a smartphone app.
From that point onwards they can start driving around.
Pricing is straightforward: you pay per minute (e.g. € 0.24) and are allowed a maximum (e.g. 250 kilometers) mileage.

## Exercise 1: Analyze existing code

Take 15 minutes to look around in the example project. What do you notice?

- Capture 3 things that you like about the example project.
- List 3 questions on things that have you puzzled.

Remind yourself of the basics of making domain models.
Open the attached booklet The Anatomy of Domain-Driven Design and read the following sections:

- Solve Complex Problems Using Models (page 3-4)
- Design a Model in Collaboration Using a Ubiquitous Language (page 7-8)
- Write Software that Explicitly Expresses the Model (page 11-12)

## Exercise 2: Enrich the Pricing Engine with the ability to extend the Reservation

Some customers complain that 20 minutes isn't enough to reach the vehicle.
For those situations it should be possible to extend the Reservation of the vehicle.
In exchange for that Cary's Cars charges € 0.09 per minute.

1.	Capture this behavior in one or more tests.
2.	Commit and push the tests.
3.	Implement the functionality within the domain model.
4.	Look for refactoring opportunities. Commit each refactor as a separate commit and push it.

## Exercise 3: Enrich the Pricing Engine with the ability exceed the included mileage

Every pay-as-you-go rental includes a maximum of 250 kilometers of mileage.
Beyond that customers should be charged an additional price of € 0.19 per kilometer.

1.	Capture the price increase for exceeding the included mileage in one or more tests.
2.	Commit and push the tests.
3.	Implement the functionality within the domain model.
4.	Look for refactoring opportunities. Commit each refactor as a separate commit and push it.
