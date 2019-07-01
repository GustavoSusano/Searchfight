Searchfight

To determine the popularity of programming languages on the internet we want to you to write an application that queries search 
engines and compares how many results they return, for example:


    C:\> searchfight.exe .net java

    .net: Google: 4450000000 MSN Search: 12354420

    java: Google: 966000000 MSN Search: 94381485

    Google winner: .net

    MSN Search winner: java

    Total winner: .net

To change the search engines, please change the configuration file Searchfight.exe.config

Searchfight only works with two search engines. It is setup to work with google and Bing (MSN Search). if you want to change, please refer in the words
in between where the ammount of sites are found. In google the words are "Cerca de " and "resultados", due to the results are shown in spanish. In bing 
words are "sb_count\">" and "resultados". However due to the use of reserved words, in configuration file it is stored "sb_count%22>" instead of "sb_count\">".

In order to keep its configuration, it is considered \" as %22 due to ascii value.

Searchfight it requires to have an internet connection and it is setup to work with results in spanish.
