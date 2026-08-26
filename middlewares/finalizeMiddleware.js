function finalizeMiddleware(req, res) {
  if (req.words.length === 0) {
    req.words.push('нуль');
  }

  const result = req.words.join(' ');

  res.json({
    number: req.originalNumber,
    result
  });
}

module.exports = finalizeMiddleware;
