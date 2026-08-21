const { hundreds } = require('../extensions/dictionaries');

// Middleware 4: обробляє розряд сотень (0..999, беремо тільки сотні)
function hundredsMiddleware(req, res, next) {
  const h = Math.floor(req.num / 100);

  if (h > 0) {
    req.words.push(hundreds[h]);
  }

  req.num = req.num % 100;
  next();
}

module.exports = hundredsMiddleware;
