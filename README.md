# MerchantFeeCalculator
MobilePay helper app for calculating merchant fees.
Project requirements can be found [here](ProjectRequirements.txt).

# Possible configuration:
- Modify Transaction and Invoice Fee services base functionality by introducing different BaseTransactionFeeServices.
    - E.g. TransactionFlatFeeService or PercentageInvoiceFeeService.
- Enchance base services with additional functionality by modifying Fee specific decorators.

# Possible improvements:
- Add Dependency Injection.
- Encapsulate console output methods.
- Implement parallel transaction fee calculation:
    - Ensure that output methods are encapsulated into a singleton.
    - Use concurrent collection in FirstMonthlyInvoiceFeeDecorator.
- Introduce decorator pattern into Fee services. 
    - Ability to dinamically add or remove BaseTransactionFeeServices.
        - E.g. Introduce FlatNewMerchantFeeService without modifying MerchantFeeCalculatorService.
    - This change introduces decorator hierarchy that is fairly complicated, thus should be avoided if not needed.