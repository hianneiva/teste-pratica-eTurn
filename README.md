# teste-pratica-eTurn
*Teste prático para o processo de seleção para vaga de desenvolvedor na eTurn.*

### Teste Prático | Analista Desenvolvedor

Devido a uma restrição orçamentária, a empresa de trens de um determinado estado decidiu que todas as suas viagens de trem seriam só de uma via, ou seja, sair da cidade A para a cidade B (não necessariamente significa que existe uma saída da cidade B para a cidade A). Além disso, mesmo que exista este trecho, ele é independente e pode ter uma distância distinta.

Esta empresa, precisa desenvolver para seus usuários um software por meio do qual será possível identificar qual é o melhor caminho para que ele chegue ao seu destino.

Hoje sabemos que:

 - A distância da cidade A até a cidade B é 5.
 - A distância da cidade B até a cidade C é 4.
 - A distância da cidade C até a cidade D é 8.
 - A distância da cidade D até a cidade C é 8.
 - A distância da cidade D até a cidade E é 6.
 - A distância da cidade A até a cidade D é 5.
 - A distância da cidade C até a cidade E é 2.
 - A distância da cidade E até a cidade B é 3.
 - A distância da cidade A até a cidade E é 7.

Escreva um programa que apresente:

1. A distância da rota A-B-C.
2. A distância da rota A-D.
3. A distância da rota A-D-C.
4. A distância da rota A-E-B-C-D.
5. A distância da rota A-E-D.
6. O número de viagens começando em C e terminando em C com no máximo 3 paradas. Baseado no contexto apresentado, serão 2 rotas possíveis: C-D-C (2 paradas) e C-E-B-C (3 paradas).
7. O numero de viagens começando em A e terminando em C com exatamente 4 paradas. Baseado no contexto apresentado, serão 3 rotas possíveis: A para C (via B,C,D); A para C (via D,C,D); e A para C (via D,E,B).
8. O tamanho da menor viagem (em termos de distância) de A para C.
9. O tamanho da menor viagem (em termos de distância) de B para B.
10. O numero de viagens começando em C e terminando em C com distância menor que 30. Baseado no contexto apresentado, serão as rotas seguintes: CDC, CEBC, CEBCDC, CDCEBC, CDEBC, CEBCEBC, CEBCEBCEBC.

A saída esperada é:

 - #1: 9
 - #2: 5
 - #3: 13
 - #4: 22
 - #5: Rota não existente
 - #6: 2
 - #7: 3
 - #8: 9
 - #9: 9
 - #10: 7
