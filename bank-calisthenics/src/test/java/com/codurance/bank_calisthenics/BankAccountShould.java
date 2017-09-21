package com.codurance.bank_calisthenics;

import static org.hamcrest.CoreMatchers.equalTo;
import static org.hamcrest.core.StringContains.containsString;
import static org.junit.Assert.assertThat;
import static org.mockito.Mockito.*;

import org.junit.Test;
import org.mockito.ArgumentCaptor;

import java.util.Date;
import java.util.List;

public class BankAccountShould {
    private final String BALANCE_HEADER = "DATE        AMOUNT   BALANCE";

    @Test
    public void have_a_balance_of_0_when_its_created() {
        Output output = mock(Output.class);
        DateProvider dateProvider = mock(DateProvider.class);

        ArgumentCaptor<String> multipleArgumentCaptor =
                ArgumentCaptor.forClass(String.class);


        doNothing().when(output).printLine(multipleArgumentCaptor.capture());

        Date date = new Date();
        when(dateProvider.currentDate()).thenReturn(date);
        BankAccount bankAccount = new BankAccount(output, dateProvider);

        bankAccount.printStatement();

        String argument = multipleArgumentCaptor.getValue();

        assertThat((String) argument, containsString("0.00"));
    }
}
