const { unitsMasculine, unitsFeminine, teens, tens, hundreds } = require('./dictionaries');

function convertTriplet(n, feminine = false) {
  const words = [];
  const h = Math.floor(n / 100);
  const rest = n % 100;

  if (h > 0) words.push(hundreds[h]);

  if (rest >= 10 && rest < 20) {
    words.push(teens[rest - 10]);
  } else {
    const t = Math.floor(rest / 10);
    const u = rest % 10;
    if (t > 0) words.push(tens[t]);
    if (u > 0) words.push((feminine ? unitsFeminine : unitsMasculine)[u]);
  }

  return words;
}

module.exports = convertTriplet;
