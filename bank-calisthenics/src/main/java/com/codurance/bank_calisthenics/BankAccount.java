package com.codurance.bank_calisthenics;

public class BankAccount {
    private final Output mockedOutput;
    private final DateProvider dateProvider;
    private final String BALANCE_HEADER = "DATE        AMOUNT   BALANCE";

    public BankAccount(Output mockedOutput, DateProvider dateProvider) {

        this.mockedOutput = mockedOutput;
        this.dateProvider = dateProvider;
    }

    public void printStatement() {
        mockedOutput.printLine(BALANCE_HEADER);
        mockedOutput.printLine("0.00");
    }

    private String getCurrentDateString() {
        return dateProvider.currentDate().toString();
    }
}
