//
//  ISFacebookAdapter.h
//  ISFacebookAdapter
//
//  Created by Yotam Ohayon on 02/02/2016.
//  Copyright © 2016 IronSource. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "IronSource/ISBaseAdapter+Internal.h"
#import "IronSource/ISGlobals.h"

static NSString * const FacebookAdapterVersion             = @"4.3.8";
static NSString *  GitHash = @"e6cfcf57e";

//System Frameworks For Facebook Adapter
@import CoreMotion;

@interface ISFacebookAdapter : ISBaseAdapter

@end
