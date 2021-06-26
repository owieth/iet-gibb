import jwt from "jsonwebtoken";

export const isAuthenticated = (req, res, next) => {
    const token = req.header('access_token');

    if (!token) {
        res.status(401).send('<p>You are not authorized!</p>');
    } else {
        try {
            jwt.verify(token, process.env.SERVER_SECRET);
            next();
        } catch (e) {
            res.status(401).json({error: 'Could not verify provided token!'});
        }
    }
}
