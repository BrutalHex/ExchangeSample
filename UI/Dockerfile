# pull the official base image  
FROM node:15.14.0-alpine3.10
EXPOSE 3000
# set your working directory  
WORKDIR /app  
 
# add `/app/node_modules/.bin` to $PATH  
ENV PATH /app/node_modules/.bin:$PATH  
 
# install application dependencies  
COPY package.json ./  
COPY package-lock.json ./  
COPY .env ./  
COPY .babelrc ./
COPY .eslintrc.json ./
COPY .prettierrc.json ./
COPY tsconfig.json ./
RUN npm install --silent  

# add app  
COPY . ./  
#RUN echo -e '/* eslint-disable camelcase */ \nexport  const REACT_APP_Host_API:string="http://$hostingvar:5001/api/";' > ./src/base/environments.ts
# will start app  
CMD ["npm", "start"] 