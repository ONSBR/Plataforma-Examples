
FROM node:carbon
WORKDIR /usr/src/cotacao-online
COPY . .
RUN cd server && npm install
CMD [ "node", "server/index.js" ]
            
