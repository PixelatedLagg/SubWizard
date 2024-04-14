# SubWizard
A tool intended to decrypt letter-substitution ciphers with high accuracy using letter frequencies. Words sourced from [this repository](https://github.com/dwyl/english-words/tree/master).

## Methodology
By calculating data from 370k English words, I believe an algorithm can somewhat accurately estimate the solution to a letter-substitution cipher.

True variables I plan to take into account:
- Probability of letter being in word (of certain size aswell)
- Proportion of letters in all words
- Proportion of letters in words that contain the specific letter
