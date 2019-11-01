FROM node:10.15.0-alpine
WORKDIR /app
ADD . /app
RUN npm install
RUN npm rebuild node-sass
RUN npm run build
ENV HOST 0.0.0.0
ENV PORT 3000
CMD [ "npm", "start" ]