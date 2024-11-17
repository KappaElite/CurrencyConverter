## **Currency Converter Tool**

This project is a currency conversion tool written in C#. It uses exchange rate data provided by the National Bank of Poland (NBP) to calculate the final value of any amount in a target currency, based on an input amount in any source currency.

### **Overview**

The tool fetches the latest exchange rate data from the NBP's website (URL: https://www.nbp.pl/kursy/xml/lasta.xml). The main functionality includes converting a specified amount from one currency to another using up-to-date average exchange rates.

### **Features**

#### Currency Conversion: Convert any amount from a source currency to a target currency based on the latest NBP exchange rates. 
#### User Input: Accepts user-defined amounts and allows selection of source and target currencies.
#### SOLID Principles: Designed following SOLID principles for maintainability and extensibility.
#### Singleton Pattern: Utilizes the Singleton pattern to ensure only one instance of the exchange rate data is fetched and used across the application.

#### **Language**: C#
#### **Design Patterns**: Singleton
#### **Architecture Principles**: SOLID
