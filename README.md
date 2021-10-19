# DesignPatterns.Factory
This is a demonstration from my DesignPattern series.

This app is a banking app.
It tells you how much you're going to pay back each month for a loan.
The calculation is based on your desired amount, loan type and payback duration (in years).

For now it has 2 loan types, Housing Loan (which has an interest rate of 3.5%) and Car Loan (which has an interest rate of 7%).
New loan types, with different interest rates can simple be added.

Also only one Concrete Creator is needed so far (Services/PaybackSchemesFactory/PaybackSchemeFactory).
More Creators can be added, which can determine different types of logic on how to chose a different PaybackScheme, or even to create new Payment Objects.
