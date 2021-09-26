# build vue app
FROM node:14-alpine as builder

WORKDIR /src
COPY "./vue-ui" "."
# set environment variables for vue app, because can use only .envs files
RUN echo "VUE_APP_SERVER_URL=http://localhost:5000" > .env

RUN npm install
RUN npm run build

# RUN rm -rf node_modules

# nginx
FROM nginx:alpine as prod
COPY ./vue-ui/nginx.conf /etc/nginx/nginx.conf

RUN rm -rf /usr/share/nginx/html/*

COPY --from=builder /src/dist /usr/share/nginx/html

ENTRYPOINT ["nginx", "-g", "daemon off;"]