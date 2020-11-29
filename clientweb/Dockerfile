FROM node:13.12.0-alpine
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
EXPOSE 80

WORKDIR /
COPY "clientweb/package.json" .
COPY "clientweb/package-lock.json" .
COPY "clientweb" .
RUN npm install 
RUN npm install react-scripts@3.4.1 -g 

COPY . .

CMD ["npm", "start"]