# Unit Testing Basics: Scenario

## Overview

Odi LLC is a company specializing in Community Financing. Community members contribute money on a monthly basis and use a "merry-go-round" method of disbursing loans.
As members increase, deposits are going up and the merry-go-round method makes members get loans >1 year.

Odi LLC is moving to a computerised system that grants members instant loans. Members can get the following loan products:
- 15K
- 75K
- 150K
- 500K

Loans are determined using members contributions as follows:

| Member Contributions | Loan Amount |
|----------------------|-------------|
| 0 - 15K              | 15K         |
| 15 - 50K             | 75K         |
| 50 - 100K            | 150K        |
| >100K - 500          | 500K        |
| >500K				   | 600K        |

Additionally, members can get a 'booster loan' on top of the loan products, by virtue of how long they have been a member as follows:

| Membership Time | Booster Loan Amount |
|-----------------|---------------------|
| Upto 1 year     | 10K                 |
| Upto 2 years    | 35K                 |
| Upto 5 years    | 100K                |
| > 5 Years       | 250K                |

## Task

Build a Loan Processing module to automatically give members loans using conditions given above.

## Starting Steps

- Read it again
- Create a dictionary with all conditions
- Create a fn to process loans for one case
- List all features to be served
- Concrete Sample