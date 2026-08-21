// Правильна форма слова "тисяча" залежно від числа
function thousandWord(n) {
  const mod100 = n % 100;
  const mod10 = n % 10;

  if (mod100 >= 11 && mod100 <= 14) return 'тисяч';
  if (mod10 === 1) return 'тисяча';
  if (mod10 >= 2 && mod10 <= 4) return 'тисячі';
  return 'тисяч';
}

module.exports = { thousandWord };
