# language: fr
Fonctionnalité: 3 French
The example comes from [**here**](https://github.com/cucumber/cucumber-ruby/blob/master/examples/i18n/fr/features/addition.feature).

Plan du Scénario: Addition de deux nombres
	Soit une calculatrice
	Et que j'entre <a> pour le premier nombre
	Et que je tape sur la touche "+"
	Et que j'entre <b> pour le second nombre
	Lorsque je tape sur la touche "="
	Alors le résultat affiché doit être <somme>

	Exemples:
		| a | b | somme |
		| 2 | 2 | 4     |
		| 2 | 3 | 5     |