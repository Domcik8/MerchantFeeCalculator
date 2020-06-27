# MerchantFeeCalculator
MobilePay helper app for calculating merchant fees.
For project requirements check: [a relative link](ProjectRequirements.md).

# Possible configuration:
- Modify Transaction and Invoice Fee services base functionality by introducing different BaseTransactionFeeServices.
    - E.g. TransactionFlatFeeService or PercentageInvoiceFeeService.
- Enchance base services with additional functionality by modifying Fee specific decorators.

# Possible improvements:
- Add Dependency Injection.
- Implement DatabaseTransactionRepository instead of TxtTransactionRepository.
- Encapsulate console output methods into singleton.
- Implement parallel transaction fee calculation:
    - Ensure that output is encapsulated into a singleton.
    - Use concurrent collection in FirstMonthlyInvoiceFixedFeeDecorator.
- Introduce decorator pattern into Fee services. 
    - Ability to dinamically add or remove BaseTransactionFeeServices.
        - E.g. Introduce FlatNewMerchantFeeService without modifying MerchantFeeCalculatorService.
    - This change introduces decorator hierarchy that is fairly complicated, thus should be avoided if not needed.