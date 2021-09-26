# build vue app
FROM node:14-alpine as builder

WORKDIR /src
COPY "./vue-ui" "."
RUN npm install
RUN npm run build

# RUN rm -rf node_modules

# using nginx
FROM nginx:alpine as prod
COPY ./vue-ui/nginx.conf /etc/nginx/nginx.conf

## Remove default nginx index page
RUN rm -rf /usr/share/nginx/html/*

# Copy from the stahg 1
COPY --from=builder /src/dist /usr/share/nginx/html

EXPOSE 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]