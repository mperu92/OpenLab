/* eslint-disable */
const path = require('path');
const webpack = require('webpack');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const TerserPlugin = require('terser-webpack-plugin');
const WebpackMd5Hash = require("webpack-md5-hash");
const WebpackBundleAnalyzer = require("webpack-bundle-analyzer");
const workboxPlugin = require('workbox-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const globImporter = require('node-sass-glob-importer');

const MODULE_BUILD_DIR = path.resolve(__dirname, './wwwroot/dist/assets/');

process.env.NODE_ENV = "production";

const config = {
	mode: "production",
	target: "web",
	devtool: "source-map",
	context: __dirname, // string (absolute path!)
	entry: [
		'@babel/polyfill',
		'font-awesome/scss/font-awesome.scss',
		'./wwwroot/js/main.js',
	],
	output: {
		path: MODULE_BUILD_DIR,
		filename: '[name].[hash].bundle.js',
		chunkFilename: '[id].[hash].chunk.js',
    },
    optimization: {
		minimize: true,
        minimizer: [
			new TerserPlugin({
				cache: true,
				parallel: true,
				terserOptions: {
					warnings: false,
					compress: {
						warnings: false,
						unused: true,
					},
					ecma: 6,
					mangle: true,
					unused: true,
				},
				sourceMap: true,
			}),
			new OptimizeCSSAssetsPlugin({
				sourceMap: true
			}),
        ],
        splitChunks: {
			chunks: 'all',
            cacheGroups: {
                commons: { 
                    test: /[\\/]node_modules[\\/]/, 
					name: "commons",
					filename: 'commons.[hash].js',
                    chunks: "all" 
                },
                styles: {
                    name: 'main',
                    test: /\.(css|.s[c|a]ss)$/,
                    chunks: 'all',
                    enforce: true
                }
            }
        }
    },
	module: {
		rules: [
			{
				test: /\.(js|jsx)$/,
				enforce: "pre",
				loader: "eslint-loader",
				exclude: /node_modules/,
				options: {
					emitWarning: true,
					configFile: "./.eslintrc.js"
				}
			  },
			{
				test: /\.(js|jsx)$/,
				exclude: /node_modules/, // exclude the node_module directory
				loader: 'babel-loader' // use this (babel-code) loader'
			},
			{
				test: /\.s[c|a]ss$/,
				use: [
                        MiniCssExtractPlugin.loader,
                        { 
                            loader: 'css-loader', 
                            options: {
                                sourceMap: true,
                                importLoaders: 3,
                            } 
                        },
                        {
                            loader: 'postcss-loader',
                            options: {
                                ident: 'postcss',
                                sourceMap: true,
                                plugins: () => [
                                    require('precss'),
                                    require("cssnano"),
                                    require('autoprefixer')({
                                        grid: true,
                                        remove: true,
                                    }),
                                    require('postcss-flexbugs-fixes'),
                                ]
                            }
                        },
						{
							loader: 'sass-loader',
							options: {
								sourceMap: true,
								sassOptions: {
									importer: globImporter()
								}
							}
						}
                    ]
			},
			{
				test: /\.css$/,
				use: [MiniCssExtractPlugin.loader, 'css-loader']
			},
			{
				test: /\.(woff(2)?|ttf|eot|svg)(\?v=\d+\.\d+\.\d+)?$/,
				use: [{
					loader: 'file-loader',
                    options: {
						mimetype: 'application/font-woff',
						name: '/Fonts/[hash].[ext]',
						publicPath: '/dist/assets/',
						postTransformPublicPath: (p) => `__webpack_public_path__ + ${p}`,
					}
				}]
			},
			// font-awesome
			{
				test: /font-awesome\.config\.js/,
				use: [
					{ loader: 'style-loader' },
					{ loader: 'font-awesome-loader' }
				]
			},
			{
				test: /\.(jpe?g|png|gif|svg)$/i,
				use: [
					'file-loader?name=images/[hash].[ext]',
					'image-webpack-loader?bypassOnDebug',
				]
			}
		],
	},
	resolve: {
		modules: [ 
			'node_modules',
			path.resolve(__dirname, './wwwroot/js'),
		],
		extensions: ['.js', '.json', '.jsx', '.css'],
		alias: {
            jquery: "jquery/src/jquery"
        }
	},
	plugins: [
        // Display bundle stats
        new WebpackBundleAnalyzer.BundleAnalyzerPlugin({ analyzerMode: "static" }),
        new CleanWebpackPlugin(),
        new MiniCssExtractPlugin({
            // Options similar to the same options in webpackOptions.output
            // both options are optional
            path: MODULE_BUILD_DIR,
            filename: './styles/[name].[contenthash].css',
          }),
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery",
            fs: "fs"
        }),
		new WebpackMd5Hash(),
		new workboxPlugin.GenerateSW({
			swDest: 'sw.js',
			clientsClaim: true,
			skipWaiting: true,
		}),
	],
	node: {
		fs: 'empty'
	},
};

module.exports = config;